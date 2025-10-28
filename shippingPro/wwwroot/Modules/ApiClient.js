const ApiClient = {
    baseUrl: 'https://localhost:7003',

    get: function (url, onSuccess, onError, useAuth = true) {
        const accessToken = AppHelper.getCookie("AccessToken");
        const headers = useAuth && accessToken
            ? { 'Authorization': 'Bearer ' + accessToken }
            : {};

        $.ajax({
            url: this.baseUrl + url,
            type: 'GET',
            contentType: 'application/json',
            headers: headers,
            xhrFields: { withCredentials: true },
            success: onSuccess,
            error: function (xhr) {
                if (useAuth && xhr.status === 401) {
                    ApiClient.refreshToken(() => {
                        ApiClient.get(url, onSuccess, onError, useAuth);
                    }, onError);
                } else if (onError) {
                    onError(xhr);
                }
            }
        });
    },

    post: function (url, data, onSuccess, onError, useAuth = true) {
        const accessToken = AppHelper.getCookie("AccessToken");
        const headers = useAuth && accessToken
            ? { 'Authorization': 'Bearer ' + accessToken }
            : {};

        $.ajax({
            url: this.baseUrl + url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers,
            xhrFields: {
                withCredentials: true
            },
            success: onSuccess,
            error: function (xhr) {
                if (useAuth && xhr.status === 401) {
                    ApiClient.refreshToken(() => {
                        ApiClient.post(url, data, onSuccess, onError, useAuth);
                    }, onError);
                } else if (onError) {
                    onError(xhr);
                }
            }
        });
    },

    refreshToken: function (onSuccess, onFailure) {
        $.ajax({               
            url: this.baseUrl + '/api/Auth/RefreshAccessToken',
            type: 'POST',
            contentType: 'application/json',
            xhrFields: {
                withCredentials: true
            },
            success: function (response) {
                if (response && response.accessToken) {
                    // بعد ما السيرفر يرجع accessToken جديد، خزنه في الكوكي
                    document.cookie = `AccessToken=${response.accessToken}; path=/`;
                    if (onSuccess) onSuccess();
                } else {
                    if (onFailure) onFailure({ message: 'Token refresh failed.' });
                }
            },
            error: function (err) {
                if (onFailure) onFailure(err);
            }
        });
    }
};

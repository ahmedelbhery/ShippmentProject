const ShipmentService =
{
    FormIds: {},
    GetModel: function () {
        const shipmentDto = {
            ShipingDate: new Date().toISOString(),
            DeliveryDate: new Date(new Date().setDate(new Date().getDate() + 3)).toISOString(),

            SenderId: "00000000-0000-0000-0000-000000000000",
            UserSender: {
                Id: "00000000-0000-0000-0000-000000000000",
                UserId: "00000000-0000-0000-0000-000000000000",
                SenderName: $('input[name="SenderName"]').val(),
                Email: $('input[name="Email"]').val(),
                Phone: $('input[name="Phone"]').val(),
                CityId: $('select[name="SenderCityId"]').val(),
                Address: $('input[name="Address"]').val(),
                Contact: $('input[name="Contact"]').val(),
                PostalCode: $('input[name="PostalCode"]').val(),
                OtherAddress: $('input[name="OtherAddress"]').val()
            },

            ReceiverId: "00000000-0000-0000-0000-000000000000",
            UserReceiver: {
                Id: "00000000-0000-0000-0000-000000000000",
                UserId: "00000000-0000-0000-0000-000000000000",
                ReceiverName: $('input[name="ReciverName"]').val(),
                Email: $('input[name="ReciverEmail"]').val(),
                Phone: $('input[name="ReciverPhone"]').val(),
                CityId: $('select[name="ReciverCity"]').val(),
                Address: $('input[name="ReciverAddress"]').val(),
                Contact: $('input[name="ReciverContact"]').val(),
                PostalCode: $('input[name="ReciverPostalCode"]').val(),
                OtherAddress: $('input[name="ReciverOtherAddress"]').val()
            },
            ShipingTypeId: $('select[name="ShippingType"]').val() || null,
                                               
            ShipingPackgingId: $('select[name="PackageType"]').val() || null,

            Width: parseFloat($('input[name="Width"]').val()) || 0,
            Height: parseFloat($('input[name="Height"]').val()) || 0,
            Weight: parseFloat($('input[name="Weight"]').val()) || 0,
            Length: parseFloat($('input[name="Length"]').val()) || 0,

            PackageValue: parseFloat($('input[name="PackageValue"]').val()) || 0,
            ShipingRate: 0.0,

            PaymentMethodId: null,
            UserSubscriptionId: null,
            TrackingNumber: null,
            ReferenceId: null
        };
        switch (this.FormIds.CurrentState) {
            case 2:
                shipmentDto.CarrierId = $('select[name="DeliveryManId"]').val() || null;
                break;
            case 3:
                shipmentDto.DelivryDate = $('input[name="DeliveryDate"]').val();
                break;
        }
        console.log(shipmentDto);
        return shipmentDto;
    },
    FillShipmentForm: function (data) {
        this.FormIds = {
            Id: data.Id,
            SenderId: data.UserSender?.Id || null,
            ReceiverId: data.UserReceiver?.Id || null,
            TrackingNumber: data.TrackingNumber || null,
            ShipingRate: data.ShipingRate || 0,
            CurrentState : data.CurrentState,
        };


        // Sender
        $('input[name="SenderName"]').val(data.UserSender?.SenderName || "");
        $('input[name="Email"]').val(data.UserSender?.Email || "");
        $('input[name="Phone"]').val(data.UserSender?.Phone || "");
        $('select[name="SenderCountry"]').val(data.UserSender?.CountryId || "");
        ManagePageControls.fillCityDropdown('select[name="SenderCityId"]', data.UserSender?.CountryId, data.UserSender?.CityId);
        $('input[name="Address"]').val(data.UserSender?.Address || "");
        $('input[name="Contact"]').val(data.UserSender?.Contact || "");
        $('input[name="PostalCode"]').val(data.UserSender?.PostalCode || "");
        $('input[name="OtherAddress"]').val(data.UserSender?.OtherAddress || "");


        // Receiver
        $('input[name="ReciverName"]').val(data.UserReceiver?.ReceiverName || "");
        $('input[name="ReciverEmail"]').val(data.UserReceiver?.Email || "");
        $('input[name="ReciverPhone"]').val(data.UserReceiver?.Phone || "");
        $('select[name="ReciverCountry"]').val(data.UserReceiver?.CountryId || "");
        ManagePageControls.fillCityDropdown('select[name="ReciverCity"]', data.UserReceiver?.CountryId, data.UserReceiver?.CityId);
        $('input[name="ReciverAddress"]').val(data.UserReceiver?.Address || "");
        $('input[name="ReciverContact"]').val(data.UserReceiver?.Contact || "");
        $('input[name="ReciverPostalCode"]').val(data.UserReceiver?.PostalCode || "");
        $('input[name="ReciverOtherAddress"]').val(data.UserReceiver?.OtherAddress || "");


        // Shipment details
        $('select[name="ShippingType"]').val(data.ShipingTypeId || "");
        $('select[name="PackageType"]').val(data.ShipingPackgingId || "");
        $('input[name="Width"]').val(data.Width ?? "");
        $('input[name="Height"]').val(data.Height ?? "");
        $('input[name="Weight"]').val(data.Weight ?? "");
        $('input[name="Length"]').val(data.Length ?? "");
        $('input[name="PackageValue"]').val(data.PackageValue ?? "");
        $('input[name="TrackingNumber"]').val(data.TrackingNumber ?? "");
        $('input[name="ShipingRate"]').val(data.ShipingRate ?? 0);


        // Dates
        if (data.ShipingDate) $('input[name="ShipingDate"]').val(new Date(data.ShipingDate).toISOString().split('T')[0]);
        if (data.DeliveryDate) $('input[name="DeliveryDate"]').val(new Date(data.DeliveryDate).toISOString().split('T')[0]);
        console.log(data.CurrentState);
        switch (data.CurrentState) {
            case 1:
                $("#mainButton").val("Approve");
                break;
            case 2:
                $("#deliveryManWrapper").show();
                $("#mainButton").val("Ready For Ship");
                break;
            case 3:
                $("#deliveryDateWrapper").show();
                $("#mainButton").val("Shipped");
                break;
            case 4:
                $("#mainButton").val("Delivred");
                $("#secandryButton").show();
                break;
        }
    },

        SaveShippment: function ()
        {
            //let data = ShipmentService.GetModel();
            //console.log("log data before send");
            //console.log(data);
            //console.log("البيانات قبل الإرسال:", data); // أضف هذا السطر
            //debugger; // ⬅️ ستتوقف هنا تلقائياً

            //ApiClient.post("/api/Shipment/Create", data, function (data) { },
            //    function (xhr)
            //    {
            ////        console.error("API Error:", xhr.responseJSON);
            //    });

            let data = ShipmentService.GetModel();

            // يمكن إضافة المزيد من التحققات هنا
            console.log("log data before send");
            console.log(data);
            console.log("البيانات قبل الإرسال:", data); // أضف هذا السطر
            ApiClient.post(`/api/Shipment/Create`, data,
                function (data) {
                    // التعامل مع الرد الناجح هنا
                    console.log("تم الإرسال بنجاح!", data);
                    alert('تم حفظ الشحنة بنجاح!');
                }, function (xhr) {
                    // هذا الجزء يحل مشكلة TypeError: Cannot read properties of undefined
                    // يتم التحقق أولاً من وجود responseJSON
                    const errorDetails = xhr.responseJSON ? xhr.responseJSON.errors : { general: "No error details provided by API." };
                    console.error("API Error:", errorDetails);
                    alert('فشل حفظ الشحنة. يرجى مراجعة البيانات. التفاصيل: ' + JSON.stringify(errorDetails));
                }
                , function (xhr) {
                    console.error("Failed to get User ID:", xhr.responseJSON);
                    alert('فشل في الحصول على معرف المستخدم. يرجى المحاولة مرة أخرى.');
                });
        },
    EditShippment: function () {
        let data = ShipmentService.GetModel();
        // ensure Ids come from FormIds if present
        data.Id = this.FormIds.Id;
        data.SenderId = this.FormIds.SenderId;
        data.ReceiverId = this.FormIds.ReciverId;
        data.TrackingNumber = this.FormIds.TrackingNumber;
        data.ShipingRate = this.FormIds.ShipingRate;

        console.log("log data before send");
        console.log(data);
        ApiClient.post("/api/Shipment/Edit", data,
            function (data) { }, function (xhr) {
                console.error("API Error:", xhr.responseJSON);
            });
    },
    ChangeStatus: function (status) {
        let data = ShipmentService.GetModel();
        data.Id = this.FormIds.Id;
        data.SenderId = this.FormIds.SenderId;
        data.ReceiverId = this.FormIds.ReciverId;
        data.TrackingNumber = this.FormIds.TrackingNumber;
        data.ShipingRate = this.FormIds.ShipingRate;

        data.CurrentState = status;
        console.log(data.CurrentState);
        console.log("log data before send");
        console.log(data);
        ApiClient.post("/api/Shipment/ChangeStatus", data,
            function (data) { }, function (xhr) {
                console.error("API Error:", xhr.responseJSON);
            });
    },
    GetShipments: function (onSuccess, onError) {
        ApiClient.get(`/api/Shipment`, onSuccess, onError, true);
    },
    GetById: function (id, onSuccess, onError) {
        ApiClient.get(`/api/Shipment/${id}`, onSuccess, onError, true);
    },
}
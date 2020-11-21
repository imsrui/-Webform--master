function ContactMe()
{
    var name = $("#orderName").val();
    var phone = $("#orderPhone").val();
    var amount = $("#orderAmount").val();

    if (name == "" || phone == "" || amount == "") {
        alert("信息填写的不完整");
    } else {

        //这个地方我们需要通过Ajax技术,进行数据传递,并且实现新增功能
        $.post("../../Handler/AddOrderHandler.ashx", { name: name, tel: phone, money: amount }, function (res) {
            if (res.result == "True") {
                alert("预约成功,稍后客服会电话与您联系,请保持通话畅通");
            } else {

                alert("预约失败");
            }
        }, "json");
    }

}
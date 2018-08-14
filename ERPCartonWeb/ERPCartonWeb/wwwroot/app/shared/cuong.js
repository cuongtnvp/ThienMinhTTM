var cuong = {
    configs: {
        pageSize: 10,
        pageIndex: 1
    },
    notify: function (message, type) {
        new  PNotify ({
            title: message,
            type: type,
            buttons: {
                closerHover: true,
                sticker: false //ugly
            },
            text: message,
            nonblock: {
                nonblock: false
            },
            saddclass: 'dark',
            styling: 'bootstrap3',
            
            animate: {
                animate: true,
                in_class: 'zoomInLeft',
                out_class: 'zoomOutRight'
            },
            hide: true,
            delay: 8000,
            remove: true
            
           
        })
    },
    confirm: function (message, okCallback) {
        $.pnotify.confirm({
            text: message,
            icon: 'glyphicon glyphicon-question-sign',
            hide: false,
            //buttons: { close: true },
            //icon: 'true',
            confirm: {
                confirm: true,
                buttons: [{
                    text: 'Dong Y',
                    addClass: 'btn-primary',
                    click: function (notice) {
                        notice.update({
                            title: 'Dong Y',
                            text: 'Yeu Cau cua ban duoc chap nhan',
                            icon: true,
                            type: 'success',
                            hide: true,
                            confirm: {
                                confirm: false
                            },
                            buttons: {
                                closer: true,
                                sticker: true
                            },
                            okCallback
                        });
                    }
                }, {
                    text: 'Huy',
                    click: function (notice) {
                        notice.update({
                            title: 'Huy',
                            text: 'He thong huy yeu cau cua ban',
                            icon: true,
                            type: 'error',
                            hide: true,
                            confirm: {
                                confirm: false
                            },
                            buttons: {
                                closer: true,
                                sticker: true
                            }
                        });
                    }
                }]
            },
            history: {
                history: false
            }
        })
    },

    dateFormatJson: function (datetime) {
        if (datetime == null || datetime =='')
            return '';
        var newdate = new Date(parseInt(datetime.substr(6)));
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        return day + "/" + month + "/" + year;
    },
    dateTimeFormatJson: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(parseInt(datetime.substr(6)));
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        var ss = newdate.getSeconds();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;
        return day + "/" + month + "/" + year + " " + hh + ":" + mm + ":" + ss;
    },
    startLoading: function () {
        if ($('.dv-loading').length > 0)
            $('.dv-loading').removeClass('hide');
    },
    stopLoading: function () {
        if ($('.dv-loading').length > 0)
            $('.dv-loading')
                .addClass('hide');
    },
    getStatus: function (status) {
        if (status == 1)
            return '<span class="badge bg-green">Kích hoạt</span>';
        else
            return '<span class="badge bg-red">Khoá</span>';
    },
    formatNumber: function (number, precision) {
        if (!isFinite(number)) {
            return number.toString();
        }

        var a = number.toFixed(precision).split('.');
        a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, '$&,');
        return a.join('.');
    },
    unflattern: function (arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i += 1) {
            var node = arr[i];
            node.children = [];
            map[node.Id] = i; // use map to look-up the parents
            if (node.ParentId !== null) {
                arr[map[node.ParentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    }
}
$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() == "POST" || options.type.toUpperCase() == "PUT") {
        var token = $('form').find("input[name='__RequestVerificationToken']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});
var InitiateSimpleDataTable = function () {
    return {
        init: function () {
            //Datatable Initiating
            var oTable = $('#simpledatatable').on('search.dt', function (p) {
                alert(p);
            }).dataTable({
                "sDom": "Tflt<'row DTTTFooter'<'col-sm-6'i><'col-sm-6'p>>",
                searching: false,
                columnDefs: [{
                    orderable: false,//禁用排序
                    targets: [0,10]   //指定的列
                }],
                lengthChange:false,
                aaSorting: [[1, "desc"]],
             
                pagingType: "full_numbers",
                language: {
                    lengthMenu: '_MENU_',//左上角的分页大小显示。
                    search: "",//右上角的搜索文本，可以写html标签
                    paginate: {//分页的样式内容。
                        previous: "上一页",
                        next: "下一页",
                        first: "第一页",
                        last: "最后"
                    },
                    zeroRecords: "没有内容",//table tbody内容为空时，tbody的内容。
                    //下面三者构成了总体的左下角的内容。
                    //     info: "总共_PAGES_ 页，显示第_START_ 到第 _END_ ，筛选之后得到 _TOTAL_ 条，初始_MAX_ 条 ",//左下角的信息显示，大写的词为关键字。
                    info: "总共_PAGES_ 页，显示第_START_ 条到第 _END_ 条 ",//左下角的信息显示，大写的词为关键字。
                    infoEmpty: "0条记录",//筛选为空时左下角的显示。
                    //     infoFiltered: ""//筛选之后的左下角筛选提示，
                },
            });

            //Check All Functionality
            $('#simpledatatable thead th input[type=checkbox]').change(function () {
                var set = $("#simpledatatable tbody tr input[type=checkbox]");
                var checked = $(this).is(":checked");
                $(set).each(function () {
                    if (checked) {
                        $(this).prop("checked", true);
                        $(this).parents('tr').addClass("active");
                    } else {
                        $(this).prop("checked", false);
                        $(this).parents('tr').removeClass("active");
                    }
                });

            });
            $('#simpledatatable tbody tr input[type=checkbox]').change(function () {
                $(this).parents('tr').toggleClass("active");
            });

        }

    };

}();

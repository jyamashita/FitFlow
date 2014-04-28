$.extend({ 
    confirmDialog: function (message, callback) {
        var html = [];
        html.push('<div class="modal fade" id="confirm-dialog">');
        html.push('<div class="modal-dialog">');
        html.push('<div class="modal-content">');
        html.push('<div class="modal-header">');
        html.push('<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>');
        html.push('<h4 class="modal-title">確認</h4>');
        html.push('</div>');
        html.push('<div class="modal-body">');
        html.push('<p>$message</p>');
        html.push('</div>');
        html.push('<div class="modal-footer">');
        html.push('<button type="button" class="btn btn-default" data-dismiss="modal">キャンセル</button>');
        html.push('<button type="button" class="btn btn-primary" data-dismiss="modal">ＯＫ</button>');
        html.push('</div>');
        html.push('</div><!-- /.modal-content -->');
        html.push('</div><!-- /.modal-dialog -->');
        html.push('</div><!-- /.modal -->');

        var $confirmDialog = $('#confirm-dialog');
        if (!$confirmDialog[0])
            $('body').append(html.join('').replace(/\$message/g, message));
        else
            $confirmDialog.find('.modal-body p').text(message);
        $confirmDialog.modal('show');
        $confirmDialog.on('click', '.btn-primary', callback);
    },
    alertDialog: function (message, callback) {
        var html = [];
        html.push('<div class="modal fade" id="alert-dialog">');
        html.push('<div class="modal-dialog">');
        html.push('<div class="modal-content">');
        html.push('<div class="modal-header">');
        html.push('<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>');
        html.push('<h4 class="modal-title">確認</h4>');
        html.push('</div>');
        html.push('<div class="modal-body">');
        html.push('<p>$message</p>');
        html.push('</div>');
        html.push('<div class="modal-footer">');
        html.push('<button type="button" class="btn btn-primary" data-dismiss="modal">ＯＫ</button>');
        html.push('</div>');
        html.push('</div><!-- /.modal-content -->');
        html.push('</div><!-- /.modal-dialog -->');
        html.push('</div><!-- /.modal -->');

        var $alertDialog = $('#alert-dialog');
        if (!$alertDialog[0])
            $('body').append(html.join('').replace(/\$message/g, message));
        else
            $alertDialog.find('.modal-body p').text(message);
        $alertDialog.modal('show');
        $alertDialog.on('click', '.btn-primary', callback);
    },
    searchDialog: function (option, callback) {
        var html = [];
        html.push('<div class="modal fade" id="search-dialog">');
        html.push('<div class="modal-dialog">');
        html.push('<div class="modal-content">');
        html.push('<div class="modal-header">');
        html.push('<button type="button" class="close">&times;</button>');
        html.push('<h4 class="modal-title"></h4>');
        html.push('</div>');
        html.push('<div class="modal-body">');
        html.push('<div class="row">');
        html.push('<form class="form-horizontal">');
        html.push('<fieldset>');
        html.push('<div class="form-group">');
        html.push('<label for="searchValue" class="col-md-2 control-label"></label>');
        html.push('<div class="col-md-8">');
        html.push('<input id="searchValue" name="search" class="form-control input-sm" type="text" />');
        html.push('</div>');
        html.push('<div class="col-md-2">');
        html.push('<button type="button" class="btn btn-primary btn-sm search">検索</button>');
        html.push('</div>');
        html.push('</div><!-- /.form-group -->');
        html.push('</fieldset>');
        html.push('</form>');
        html.push('</div><!-- /.row -->');
        html.push('<div class="row search-data">');
        html.push('<table class="table table-striped table-bordered">');
        html.push('<thead>');
        html.push('</thead>');
        html.push('<tbody>');
        html.push('</tbody>');
        html.push('</table>');
        html.push('</div><!-- /.row -->');
        html.push('</div><!-- /.modal-body -->');
        html.push('</div><!-- /.modal-content -->');
        html.push('</div><!-- /.modal-dialog -->');
        html.push('</div>');

        $('body').append(html.join(''));
        var $searchDialog = $('#search-dialog');
        $searchDialog.find('.modal-title').text(option.title + '一覧');
        $searchDialog.find('[for="searchValue"]').text(option.title);
        $searchDialog.find('form').attr('action', option.url);
        $searchDialog.modal({ show: true, backdrop: 'static' });
        $searchDialog.on('click', '.close', function () {
            $(this).parents('.modal').modal('hide')
        });
        $searchDialog.on('hidden.bs.modal', function () {
            $(this).remove();
        });
        var func = function () {
            var $search = $(this);
            var $table = $searchDialog.find('table');
            $table.parents('.search-data').loading('start', function () {
                $.ajax({
                    type: 'POST',
                    url: $search.parents('form').attr('action'),
                    data: $search.parents('form').serializeArray(),

                })
                .done(function (data) {
                    $table.parents('.search-data').loading('stop', function () {
                        $table = $searchDialog.find('table');
                        if (!$.fn.DataTable.fnIsDataTable($table[0])) {
                            $table.initSelectDataTable({ data: data, hidden: option.hidden }, callback);
                        } else {
                            $table.dataTable().fnClearTable();
                            jQuery.each(data.data, function () {
                                this.push('');
                            });
                            $table.dataTable().fnAddData(data.data);
                        }
                    });
                })
                .always(function () {
                    $table.parents('.search-data').loading('stop');
                });
            });
        }

        $searchDialog.on('submit', 'form', function () {
            func.apply($searchDialog.find('.search'));
            return false;
        });
        $searchDialog.on('click', '.search', function () {
            func.apply(this);
        });

    },
    /*
    fitflowAjax: function (option, callback) {
        $.ajax({
            type: option.type,
            dataType: 'json',
            url: option.url,
            data: option.data
        })
        .done(function (data) {
            callback(data);
        })
        .fail(function (e) {
            console.log(e);
        })
        .always(function () {

        });
    },
    */
});

$.fn.loading = function (option, callback) {
    $target = $(this);

    if (option == 'start') {
        $target.addClass('relative');
        $target.append('<div class="loading"><div class="radius"></div>');
        $target.find('.loading').hide().fadeIn('normal', callback);
    }

    if (option == 'stop') {
        $('.loading').fadeOut('normal', function () {
            $target.find('.loading').remove();
            $target.removeClass('relative');
            callback();
        });
    }
}

$.fn.initSelectDataTable = function (option, callback) {

    var data = option.data;
    var hidden = option.hidden;

    // 選択列追加
    var aoColumnDefs = [];
    var width = 90 / (data.head.length - hidden.length);
    jQuery.each(data.head, function (i) {
        if (hidden.indexOf(i) >= 0) {
            aoColumnDefs.push({ bSearchable: false, bVisible: false, aTargets: [i] });
        }
        data.head[i] = { sTitle: this, sWidth: width + '%' };
    });
    data.head.push({ sTitle: '選択', sWidth: '10%', sClass: 'text-center' });
    jQuery.each(data.data, function () {
        this.push('');
    });
    $(this).dataTable({
        aaData: data.data,
        aoColumns: data.head,
        aoColumnDefs: aoColumnDefs,
        sDom: "<'row'>t<'row'<'col-md-4'i><'col-md-8'p>r>",
        oLanguage: {
            sInfo: "表示_START_～_END_件 全_TOTAL_件",
            oPaginate: {
                sPrevious: "前",
                sNext: "次",
            },
        },
        sPaginationType: 'bootstrap',
        iDisplayLength: 9,
        fnCreatedRow: function(nRow, aData, iDataIndex) {
            var $button = $('<button>')
                .text('選択')
                .addClass('btn btn-success btn-xs')
                .attr('type', 'button')
                .click(function () {
                    callback(aData);
                    $(this).parents('.modal').modal('hide');
                });
            var $td = $('td:last', nRow);
            $td.append($button);
            $(nRow).append($td);
        },
    });
}

$(document).ready(function () {

    $('.content').on('click', '.search-dialog', function () {
        var title = $(this).attr('data-search-title');
        var url = $(this).attr('data-search-url');
        var target = $(this).attr('data-target');
        var clear = $(this).attr('data-clear');
        var $dsp = $(target);
        var $val = $(target + 'Value');
        var $dspClear = $(clear);
        var $valClear = $(clear + 'Value');
        $.searchDialog({
            title: title,
            url: url,
            hidden: [0],
            defaultValue: '',
        }, function (data) {
            $val.val(data[0]);
            $dsp.val(data[1]);
            if ($dspClear[0]) $dspClear.val('');
            if ($valClear[0]) $valClear.val('');
        })
    });

    $('.content').on('click', '.search-pair-dialog', function () {
        var title = $(this).attr('data-search-title');
        var url = $(this).attr('data-search-url');
        var target1 = $(this).attr('data-target1');
        var target2 = $(this).attr('data-target2');
        var $dsp1 = $(target1);
        var $val1 = $(target1 + 'Value');
        var $dsp2 = $(target2);
        var $val2 = $(target2 + 'Value');
        $.searchDialog({
            title: title,
            url: url,
            hidden: [0,2],
            defaultValue: '',
        }, function (data) {
            $val1.val(data[0]);
            $dsp1.val(data[1]);
            $val2.val(data[2]);
            $dsp2.val(data[3]);
        })
    });

    $('.content').on('click', '.clear-input', function () {
        var target = $(this).attr('data-target');
        $(target).val('');
        $(target + 'Value').val('');
    });
    

    $('.content').on('click', '.btn-primary', function () {
        $.confirmDialog('test');
    });

    if (0 < $(".add-item").length) {
        alert('add');
    }

});

;(function($) {

})(jQuery);
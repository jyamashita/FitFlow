$(document).ready(function () {
    methods.draw();
    methods.initSwimlane();
});

var methods = {
        draw: function () {
            /* canvas要素のノードオブジェクト */
            var canvas = document.getElementById('canvassample');
            /* canvas要素の存在チェックとCanvas未対応ブラウザの対処 */
            if (!canvas || !canvas.getContext) {
                return false;
            }
            /* 2Dコンテキスト */
            var ctx = canvas.getContext('2d');
            /* 四角を描く */
            ctx.beginPath();
            ctx.moveTo(20, 20);
            ctx.lineTo(120, 20);
            ctx.lineTo(120, 120);
            ctx.lineTo(20, 120);
            ctx.closePath();
            ctx.stroke();
        },

        initTask: function () {
            $(".swimlane.uml-model-instance .panel-body").droppable({
                accept: ".task.uml-model-master",
                tolerance: 'intersect',

                drop: function (e, ui) {
                    var $model = ui.draggable.clone().removeClass('uml-model-master').addClass('uml-model-instance');
                    $model.appendTo(this)
                    $model.draggable({
                        helper: 'original',
                        containment: 'parent',
                    });
                }
            });
        },

        start: function () {

        },

        end: function () {

        },

        getPoints: function () {
            return {
                p1: {x: $(this).position().left, y: $(this).position().top},
                p2: {x: $(this).position().left + $(this).width(), y: $(this).position().top},
                p3: {x: $(this).position().left + $(this).width(), y: $(this).position().top + $(this).height()},
                p4: {x: $(this).position().left, y: $(this).position().top + $(this).height()},
            };
        },

        isInclude: function (points, point) {
            if (points.p1.x <= point.x && point.x <= points.p2.x && points.p1.y <= point.y && point.y <= points.p4.y) {
                return true;
            } else {
                return false;
            }
            
        },

        isHover: function () {
            var ishover = false;
            var mPoint = methods.getPoints.call(this);
            $(this).siblings().each(function () {
                var tPoint = methods.getPoints.call(this);
                if (methods.isInclude(mPoint, tPoint.p1) ||
                    methods.isInclude(mPoint, tPoint.p2) ||
                    methods.isInclude(mPoint, tPoint.p3) ||
                    methods.isInclude(mPoint, tPoint.p4)) {
                    ishover = true;
                }
            });
            return ishover;
        },

        idx: 1,
        initSwimlane: function () {
            $('.uml-model-master').draggable({
                helper: 'clone',
                revert: false,
                zIndex: 100
            });

            $("#uml-canvas").sortable();
            $("#uml-canvas").droppable({
                accept: ".swimlane.uml-model-master",
                tolerance: 'fit',
                drop: function (e, ui) {
                    var $model = ui.draggable.clone().removeClass('uml-model-master').addClass('uml-model-instance');
                    $model.appendTo(this);
                    $model.find('.panel-body').droppable({
                        accept: '.uml-model:not(.swimlane)',
                        tolerance: 'fit',
                        hoverClass: 'swimlane-hover',
                        drop: function (e, ui) {
                            if (ui.draggable.hasClass('uml-model-master')) {
                                var $model = ui.draggable.clone().removeClass('uml-model-master').addClass('uml-model-instance');
                                $model.attr('id', 'uml-model-' + methods.idx++);
                                $model.appendTo(this);
                                $model.draggable({
                                    revert: function () {
                                        if ($(this).parents('.swimlane').hasClass('dragging-uml-model'))
                                            return true;
                                        if (methods.isHover.call(this))
                                            return true;
                                        else
                                            return false;
                                    },
                                    start: function (e, ui) {
                                        $(this).parents('.swimlane').addClass('dragging-uml-model');
                                    },
                                    stop: function (e, ui) {
                                        $("#uml-canvas").find('.swimlane').removeClass('dragging-uml-model');
                                    },
                                });
                                $model.offset(ui.offset);
                            } else {
                                ui.draggable.appendTo(this);
                                ui.draggable.offset(ui.offset);
                                $("#uml-canvas").find('.swimlane').removeClass('dragging-uml-model');
                            }
                        }
                    });
                }
            });
        },

};
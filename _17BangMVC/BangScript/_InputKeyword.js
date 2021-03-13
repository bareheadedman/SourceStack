$(document).ready(
    function ()
    {

        //点击加载一级关键字
        $("[bang-keyword-load-1]").click(
            function ()
            {
                $.ajax({
                    url: "/Shared/SelectedKeyword",
                    method: "POST",
                    data: "level=" + 1,
                    beforeSend: function ()
                    {

                    },
                    success: function (data)
                    {
                        var $data = $(data);
                        //给每个关键字绑定事件以生成隐藏文本域的value,并显示在关键字栏 并获得二级关键字
                        $data.find("a").click(
                            function ()
                            {
                                var keywords = $("[bang-keyword]")[0].value.split("|");
                                //判断关键字是否重复重复则不生效
                                for (var i = 0; i < keywords.length; i++)
                                {
                                    if (keywords[i] == this.innerText)
                                    {
                                        break;
                                    }
                                    if (keywords.length - 1 == i)
                                    {
                                        $("[bang-keyword]")[0].value += "|" + this.innerText;
                                        $keywordItem = $(`<span class="badge">${this.innerText}<small><span class="fa fa-times"></span></small></span>`);
                                        $($keywordItem).insertAfter($("[bang-keyword-show]").find("br"));
                                    }// else nothing


                                }

                                $.ajax({
                                    url: "/Shared/SelectedKeyword",
                                    method: "POST",
                                    data: "name=" + this.innerText,
                                    beforeSend: function ()
                                    {

                                    },
                                    success: function (data)
                                    {
                                        var $data = $(data);
                                        //给每个关键字绑定事件以生成隐藏文本域的value,并显示在关键字栏 
                                        $data.find("a").click(
                                            function ()
                                            {
                                                var keywords = $("[bang-keyword]")[0].value.split("|");
                                                //判断关键字是否重复重复则弹出警告框
                                                for (var i = 0; i < keywords.length; i++)
                                                {
                                                    if (keywords[i] == this.innerText)
                                                    {
                                                        $("[bang-keyword-modal-body]").html($(`<span>关键字 <span class="badge">${this.innerText}</span>重复了 </span>`));
                                                        $('[bang-keyword-modal]').modal("show");
                                                        break;
                                                    }
                                                    if (keywords.length - 1 == i)
                                                    {
                                                        $("[bang-keyword]")[0].value += "|" + this.innerText;
                                                        $keywordItem = $(`<span class="badge">${this.innerText}<small><span class="fa fa-times"></span></small></span>`);
                                                        $($keywordItem).insertAfter($("[bang-keyword-show]").find("br"));
                                                    }
                                                }

                                            }
                                        )
                                        $("[bang-keywordList-2]").html($data);
                                    },
                                    error: function ()
                                    {


                                    },
                                    complete: function ()
                                    {

                                    }

                                })


                            }
                        )
                        $("[bang-keywordList-1]").html($data);
                    },
                    error: function ()
                    {


                    },
                    complete: function ()
                    {

                    }

                })
            }


        )
        //一级关键字未选弹出警告
        $("[ bang-keywrod-load-2]").click(
            function ()
            {
                if ($("[bang-keywordList-2]").children("li").length == 0)
                {
                    $("[bang-keyword-modal-body]").html($('<span>还没有选择 --- 1级 --- 关键字呢。</span>'));
                    $('[bang-keyword-modal]').modal("show")
                }
            }
        )

        //自定义关键字
        $("[bang-keywork-userDefine]").keyup(
            function (event)
            {
                //判断输入的是否是空格
                if (event.keyCode == 32)
                {
                    //判断输入的第一个是不是空格
                    if ($("[bang-keywork-userDefine]")[0].value == " ")
                    {
                        $("[bang-keywork-userDefine]")[0].value = "";
                    } else
                    {
                        var keywords = $("[bang-keyword]")[0].value.split("|");
                        var value = $("[bang-keywork-userDefine]")[0].value.split(" ")[0];
                        //判断关键字是否重复重复则弹出警告框
                        for (var i = 0; i < keywords.length; i++)
                        {
                            if (keywords[i] == value)
                            {
                                $("[bang-keyword-modal-body]").html($(`<span>关键字 <span class="badge">${value}</span>重复了 </span>`));
                                $('[bang-keyword-modal]').modal("show");
                                $("[bang-keywork-userDefine]")[0].value = "";
                                break;
                            }
                            if (keywords.length - 1 == i)
                            {
                                $("[bang-keyword]")[0].value += "|" + value;
                                $keywordItem = $(`<span class="badge">${value}<small><span class="fa fa-times"></span></small></span>`);
                                $($keywordItem).insertAfter($("[bang-keyword-show]").find("br"));
                                $("[bang-keywork-userDefine]")[0].value = "";
                            }
                        }

                    }
                }
            }
        )
    }
)







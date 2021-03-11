$(document).ready(
    function ()
    {
        //进行邀请人提示查询
        $("[bang-invitedBy-name]").blur(
            function ()
            {
                $.ajax({
                    url: "/SelectedUser/Index",
                    method: "POST",
                    data: "name=" + $("[bang-invitedBy-name]")[0].value,
                    beforeSend: function ()
                    {

                    },
                    success: function (data)
                    {
                        var $data = $(data);
                        $data.find("[bang-selected-invited-radio]").find("label").change(
                            function ()
                            {
                                $("[bang-invitedBy-name]")[0].value = this.innerText.trim();
                            });

                        $data.insertAfter($("[bang-invitedBy]"));
                    },
                    error: function ()
                    {
                        x

                    },
                    complete: function ()
                    {

                    }

                })
            }


        )
        $("[bang-invitedBy-name]").focus(
            function ()
            {
                $("[bang-selected-invited]").remove();
            })

    }
)




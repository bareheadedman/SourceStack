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

        //验证码框获得焦点显示验证码图面
        $("[bang-input-image-code]").focus(
            function ()
            {
                if ($("[bang-image-code-reminder]").get(0).style.display != "none")
                {
                    $("[bang-image-code-reminder]").get(0).style.display = "none";
                } //else nothing
                if ($("[bang-refresh-image-code]").get(0).style.display == "none")
                {
                    $("[bang-refresh-image-code]").get(0).style.display = "revert";
                }  //else nothing
                if ($("[bang-image-code]").get(0).style.display == "none")
                {
                    $("[bang-image-code]").get(0).style.display = "revert";
                } //else nothing




            })

        $("[bang-refresh-image-code]").click(
            function (event)
            {
                event.preventDefault();
                $("[bang-image-code]")[0].src = "/Shared/GetImageCode?NumberKey=" + Math.random();
            })

    }
)




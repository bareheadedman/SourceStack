$(document).ready(
    function ()
    {
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

        //进行验证码的刷新
        $("[bang-refresh-image-code]").click(
            function (event)
            {
                event.preventDefault();
                $("[bang-image-code]")[0].src = "/Shared/GetImageCode?NumberKey=" + Math.random();
            })

    })






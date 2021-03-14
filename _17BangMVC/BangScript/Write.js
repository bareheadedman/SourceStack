$(document).ready(
    function ()
    {
        //绑定上传文件按钮
        $(`[bang-image-preview]`).click(
            function ()
            {
                $(`[bang-image-file]`).click()

            }
        )

        //选择文件后触发事件
        $(`[bang-image-file]`).change(
            function ()
            {
                var $modalbody = $("[bang-modal-body]");
                var $modal = $('[bang-modal]');


                if (this.files.length > 1)
                {
                    $modalbody.html($('<span>上传的图片只能接受一张</span>'));
                    $modal.modal("show");
                    return;
                } // else nothing
                var image = this.files[0];
                if (image.size > (256 * 1024))
                {
                    $modalbody.html($('<span>上传的图片大小不能超过256KB</span>'));
                    $modal.modal("show");
                    return;
                } // else nothing
                if (image.type != "image/jpg" && image.type != "image/png" && image.type != "image/gif" && image.type != "image/jpeg")
                {
                    $modalbody.html($('<span>上传的图片格式只能为 png/jpg/jpeg/gif</span>'));
                    $modal.modal("show");
                    return;
                } // else nothing

                $(`[bang-image-source]`).val($(`[bang-image-file]`)[0].value)

                var formData = new FormData();
                formData.append('file', image);
                //传给后台拿到预览图片的路径
                $.ajax({
                    url: "/Shared/ImagePreview",
                    method: "POST",
                    data: formData,
                    processData: false,
                    contentType: false,
                    beforeSend: function ()
                    {

                    },
                    success: function (data)
                    {
                        $(`[bang-image-preview]`)[0].src = data
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

    }
)





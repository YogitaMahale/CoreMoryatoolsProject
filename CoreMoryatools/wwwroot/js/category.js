﻿var datatable;
$(document).ready(function () {


    loadtable();
});

function loadtable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Category/GetALL"
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20% " },
 
            {
                "data": "img",
                "render": function (data) {
                    return ` <img src='${data}'   width="50" height="50"/>`
                }, "width": "10%"

            },
            {
                "data": "isactive",
                "render": function (data) {
                    if (data) {
                        return ` <input type="checkbox" checked="checked" />`
                    }
                    else {
                        return ` <input type="checkbox"  />`
                    }
                   
                }, "width": "10%"

            }
            , { "data": "shortdesc", "width": "40% " },
          
            //{ "data": "img", "width": "30% " },
          
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Admin/Category/Edit/${data}" class="btn btn-sm btn-success text-white" style="cursor:pointer">
   <i class="os-icon os-icon-ui-49"></i>
         Edit
    </a>
 &nbsp;
    <a  class="btn btn-sm btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/Category/Delete/${data}")>
        <i class="os-icon os-icon-ui-15"></i>Delete
    </a>
</div>`
                }, "width": "20%" 

            }

        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text:"You will not be able to restore the data",
        icon:"warning",
        buttons: true,
        dangerMode:true

    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url:url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                      /*  dataTable.ajax.reload()*/;
                        $('#tblData').DataTable().ajax.reload()
                    }
                    else {
                        toastr.error(data.message); 
                    }
                }
            });
        }


    });

}
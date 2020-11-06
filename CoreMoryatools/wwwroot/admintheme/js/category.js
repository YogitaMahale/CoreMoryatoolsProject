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
            { "data": "Name", "width": "30% " },

            { "data": "img", "width": "30% " },
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Admin/Category/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
        Edit
    </a>
    <a  class="btn btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/Category/Delete/${data}")>
        Delete
    </a>
</div>`
                }, "width": "40%" 

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
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message); 
                    }
                }
            });
        }


    });

}
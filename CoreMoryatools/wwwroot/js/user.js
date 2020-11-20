﻿var datatable;
$(document).ready(function () {


    loadtable();
});

function loadtable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetALL"
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30% " },

            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            //{ "data": "company.name", "width": "15%" },
            { "data": "role", "width": "15%" },
            {
                "data": {
                    id: "id", lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        return `
<div class="text-center">

    <a  class="btn btn-danger text-white" style="cursor:pointer" onclick=Lockunlock('${data.id}')>
       <i class="fas fa-lock-open"></i> Unlock
    </a>
</div>`
                    }
                    else {
                        return `
<div class="text-center">

    <a  class="btn btn-success text-white" style="cursor:pointer" onclick=Lockunlock('${data.id}')>
       <i class="fas fa-lock"></i> Lock
    </a>
</div>`
                    }




                }, "width": "40%"

            }

        ]
        , "bDestroy": true
    });
}

function Lockunlock(id) {
    
            $.ajax({
                type: "POST",
                url: '/Admin/User/Lockunlock',
                data: JSON.stringify(id),
                contentType:"application/json",

                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        //dataTable.ajax.reload();
                        $('#tblData').DataTable().ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
         

}
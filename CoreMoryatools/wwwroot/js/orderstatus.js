var datatable;
$(document).ready(function () {


    loadtable();
});

function loadtable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/orderstatus/GetALL"
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [
            { "data": "type", "width": "20% " }
 
             
           
            
            , { "data": "notificationMsg", "width": "40% " },
          
            //{ "data": "img", "width": "30% " },
          
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Admin/orderstatus/Edit/${data}" class="btn btn-sm btn-success text-white" style="cursor:pointer">
   <i class="os-icon os-icon-ui-49"></i>
         Edit
    </a>
 &nbsp;
    <a  class="btn btn-sm btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/orderstatus/Delete/${data}")>
        <i class="os-icon os-icon-ui-15"></i>Delete
    </a>
</div>`
//                    return `
//<div class="text-center">
//    <a href="/Admin/country/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer">
//        Edit
//    </a>
//    <a  class="btn btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/country/Delete/${data}")>
//        Delete
//    </a>
//</div>`
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
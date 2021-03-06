﻿var datatable;
$(document).ready(function () {


  //  loadtable();
});

function loadtable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetALL"
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [

            
            { "data": "id", "width": "20% " },
            { "data": "productname", "width": "20% " },
            // {
            //     "data": "isactive",
            //    "render": function (data) {
            //        return ` <input class="form-control"  type="checkbox" /> 

            //             ` 
            //    }, "width": "20%"

            //},
            { "data": "sku", "width": "20% " },
            { "data": "landingPrice", "width": "20% " },
            { "data": "superwholesaleprice", "width": "20% " },
            { "data": "dealerprice", "width": "20% " },
            { "data": "wholesaleprice", "width": "20% " },
            { "data": "customerprice", "width": "20% " },          
            { "data": "gst", "width": "20% " },
            { "data": "quantites", "width": "20% " },
            { "data": "realStock", "width": "20% " },
             
 
            //{
            //    "data": "img",
            //    "render": function (data) {
            //        return ` <img src='${data}'   width="50" height="50"/>`
            //    }, "width": "20%"

            //}
            
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Admin/Product/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer">
        Edit
    </a>
    <a  class="btn btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/Product/Delete/${data}")>
        Delete
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


function loadtable1(id) {
  //  alert(id);
    var data = JSON.stringify({
        'categoryid': id
        //,
        //'IsPrimary': true
    });

    datatable = $('#tblData').DataTable({
        "ajax": {
           // "url": "/Admin/Product/GetALL" ,
            "url": "/Admin/Product/GetALL?categoryid=" + id
           // "data": data
            // "type": "GET",
            //"datatype": "json"
        },
        "columns": [


            { "data": "id", "width": "20% " },
            { "data": "productname", "width": "20% " },
            { "data": "sku", "width": "20% " },
            { "data": "landingPrice", "width": "20% " },
            { "data": "superwholesaleprice", "width": "20% " },
            { "data": "dealerprice", "width": "20% " },
            { "data": "wholesaleprice", "width": "10% " },
            { "data": "customerprice", "width": "10% " },
            { "data": "gst", "width": "10% " },
            { "data": "quantites", "width": "10% " },
            { "data": "realStock", "width": "10% " },


            //{
            //    "data": "img",
            //    "render": function (data) {
            //        return ` <img src='${data}'   width="50" height="50"/>`
            //    }, "width": "20%"

            //}

            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Admin/Product/Edit/${data}" class="btn btn-sm btn-success text-white" style="cursor:pointer">
   <i class="os-icon os-icon-ui-49"></i>
         Edit
    </a>
 &nbsp;
    <a  class="btn btn-sm btn-danger text-white" style="cursor:pointer" onclick=Delete("/Admin/Product/Delete/${data}")>
        <i class="os-icon os-icon-ui-15"></i>Delete
    </a>
</div>`
//                    return `
//<div class="text-center">
//    <a href="/Admin/Product/Edit/${data}" class="btn btn-sm btn-success text-white" style="cursor:pointer">
//       <i class="os-icon os-icon-ui-49"></i> Edit
//    </a>
//&nbsp;
//    <a  class="btn btn-danger btn-sm text-white" style="cursor:pointer" onclick=Delete("/Admin/Product/Delete/${data}")>
//     <i class="os-icon os-icon-ui-15"></i>    Delete
//    </a>
//</div>`
                }, "width": "70%"

            }

        ]
        , "bDestroy": true
    });
}

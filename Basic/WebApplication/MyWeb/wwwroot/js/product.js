$(document).ready(function () {

    loadDataTable();
});

const loadDataTable = () => {
    const table = new DataTable('#productData', {
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "productName", "width": "20%" },
            { "data": "description", "width": "20%" },
            { "data": "listPrice", "width": "10%" },
            { "data": "price", "width": "10%" },
            {
                "data": "productID",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Product/Upsert?id=${data}"
                        class="btn btn-success mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>
                        <a onClick=Delete('/Admin/Product/Delete/${data}')
                        class="btn btn-warning mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
					</div>
                        `
                },
                "width": "15%"
            }
        ]
    });
}
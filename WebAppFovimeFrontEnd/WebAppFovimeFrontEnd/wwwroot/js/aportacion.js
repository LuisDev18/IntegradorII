
var datatable_aportaciones;
$(document).ready(function () {    
    GetAllAportaciones();
    
});

function GetAllAportaciones() {        
    
    datatable_aportaciones = $('#tb_aportaciones').DataTable({
        "ajax": {            
            "url": rootUrl + "/Aportacion/GetAportaciones",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [                        
            { "data": "n_i_anhio"},
            { "data": "n_n_aporte01"},
            { "data": "n_n_aporte02" },
            { "data": "n_n_aporte03" },
            { "data": "n_n_aporte04" },
            { "data": "n_n_aporte05" },
            { "data": "n_n_aporte06" },
            { "data": "n_n_aporte07" },
            { "data": "n_n_aporte08" },
            { "data": "n_n_aporte09" },
            { "data": "n_n_aporte10" },
            { "data": "n_n_aporte11" },
            { "data": "n_n_aporte12" },
            { "data": "n_n_total" },
        ],
        "language": {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
        },
        dom: "Bfrtip",
        buttons: [
            {
                extend: "excelHtml5",
                text: "<span title='Exportar a Excel'><img src='" + rootUrl +"/img/excel.png' /> Exportar Excel</span>",
                filename: "Reporte de créditos",
                title: "",                
                exportOptions: {
                    columns:[0,1,2]
                },
                className: "btn-export-excel"
            },            
            {
                extend: "pdfHtml5",
                text: "<span title='Exportar a PDF'><img src='" + rootUrl + "/img/pdf.png' /> Exportar PDF</span>",
                filename: "Reporte de créditos",
                title: "Reporte detallado de créditos",
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: "btn-export-pdf"
            },
            {
                extend: "print",                
                text: "<span title='Imprimir registros'><img src='" + rootUrl + "/img/printer.png' /> Imprimir</span>",
                title: "Reporte detallado de créditos",
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: "btn-print"
            },
            "pageLength"
        ],
        "width": "35%",
        "lengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]],

        "footerCallback": function (row, data, start, end, display) {
            var api = this.api(), data;

            // Remove the formatting to get integer data for summation
            var intVal = function (i) {
                return typeof i === 'string' ?
                    i.replace(/[\$,%]/g, '') * 1 :
                    typeof i === 'number' ?
                        i : 0;
            };

            // Total over all pages

            total13 = api
                .column(13)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            // Total over this page
            pageTotal13 = api
                .column(13, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            // Update footer
            //$(api.column(13).footer()).html(Math.round(pageTotal13 * 1.0).toFixed(2));            
            $(api.column(13).footer()).html(pageTotal13.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));            
            
        }
    });
}


var datatable_credits;
var datatable_credits_detail;
$(document).ready(function () {
    
    GetAllCredits();
    
});

function GetAllCredits() {  
    datatable_credits = $('#tb_creditos').DataTable({
        "ajax": {
            //"contentType" : "application/x-www-form-urlencoded;charset=utf-8",
            "url": rootUrl + "/Credito/GetAllCredits",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "c_c_expediente"},
            { "data": "n_i_cronograma"},
            { "data": "d_liquidacion"},
            { "data": "c_t_moneda"},
            { "data": "n_N_total"},
            { "data": "c_t_producto"},
            {
                "data": "c_c_expediente",
                "render": function (data) {
                    return `<div class="text-center">                        
                                <img onclick="GetAllCreditsDetails('${data}')" src="${rootUrl}/img/zoom.png"  title="Ver detalle del crédito" style="cursor:pointer"/>
                            </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
        },        
        "lengthMenu": [[5, 10, 25, -1], [5, 10, 25, "All"]],
        "paging": true,
        "ordering": true,
        "info": true,
        "searching": true
    });        
}

function GetAllCreditsDetails(expediente) {    
    document.getElementById("panel_creditos_detalle").style.display = "block"; 

    $('#tb_creditos_detalle').DataTable().destroy();
    datatable_credits_detail = $('#tb_creditos_detalle').DataTable({
        "ajax": {            
            "url": rootUrl + "/Credito/GetAllCreditsDetail?expediente=" + expediente,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "n_i_cuota" },
            { "data": "c_t_concepto" },
            { "data": "d_vencimiento" },
            { "data": "n_n_saldoini" },
            { "data": "n_n_capital" },
            { "data": "n_n_intprg" },
            { "data": "n_n_cuota" },
            { "data": "n_n_cuotat" },
            { "data": "n_n_segprg" },
            { "data": "n_n_comprg" },
            { "data": "n_n_total" },
            { "data": "c_t_estado1" },
            { "data": "c_t_estado" }
                        
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

            total4 = api
                .column(4)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            total5 = api
                .column(5)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            total6 = api
                .column(6)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            total7 = api
                .column(7)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            total8 = api
                .column(8)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            total9 = api
                .column(9)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            total10 = api
                .column(10)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            // Total over this page
            pageTotal4 = api
                .column(4, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            pageTotal5 = api
                .column(5, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            pageTotal6 = api
                .column(6, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            pageTotal7 = api
                .column(7, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            pageTotal8 = api
                .column(8, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            pageTotal9 = api
                .column(9, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            pageTotal10 = api
                .column(10, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);

            // Update footer                       

            $(api.column(4).footer()).html(pageTotal4.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(5).footer()).html(pageTotal5.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(6).footer()).html(pageTotal6.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(7).footer()).html(pageTotal7.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(8).footer()).html(pageTotal8.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(9).footer()).html(pageTotal9.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(10).footer()).html(pageTotal10.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));

        }

    });
}

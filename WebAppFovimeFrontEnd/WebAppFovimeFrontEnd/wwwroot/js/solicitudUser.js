
var datatable_solicitudes;
var datatable_solicitudes_detail;
$(document).ready(function () {
    
    GetSolicitudesBySocio();
    
});

function GetSolicitudesBySocio() {
    debugger;
    datatable_solicitudes = $('#tb_solicitudes').DataTable({
        "ajax": {            
            "url": rootUrl + "/Simulator/GetSolicitudesBySocio",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idSimulacion"},            
            { "data": "d_documento" },
            { "data": "n_i_plazo" },
            { "data": "n_n_cuota" },
            { "data": "n_n_monto" },
            { "data": "comentarios" },
            {
                "data": "idEstado",
                "render": function (data) {
                    if (data == "1") //Aprobado
                    {
                        return `<div class="text-center"><img src="${rootUrl}/img/ok.png"  title="Aprobado" style="cursor:pointer"/></div>`;
                    }
                    else if (data == "2") //Pendiente
                    {
                        return `<div class="text-center"><img src="${rootUrl}/img/time.png"  title="Pendiente" style="cursor:pointer"/></div>`;
                    }
                    else if (data == "3") //Rechazado
                    {
                        return `<div class="text-center"><img src="${rootUrl}/img/x-mark.png"  title="Rechazado" style="cursor:pointer"/></div>`;
                    }                    
                }
            },
            {
                "data": "idSimulacion",
                "render": function (idSimulacion) {                    
                        return `<span class="text-center">                        
                                <img onclick="GetSolicitudDetail(${idSimulacion})" src="${rootUrl}/img/zoom.png"  title="Ver detalle de la solicitud" style="cursor:pointer"/>
                            </span>`;                    
                }
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


function GetSolicitudDetail(idSimulacion) {
    document.getElementById("panel_solicitudes_detalle").style.display = "block";

    $('#tb_solicitudes_detalle').DataTable().destroy();
    datatable_solicitudes_detail = $('#tb_solicitudes_detalle').DataTable({
        "ajax": {
            "url": rootUrl + "/Simulator/GetSolicitudDetail?idSimulacion=" + idSimulacion,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "n_i_cuota" },
            { "data": "d_vencimiento" },            
            { "data": "n_n_saldoini" },
            { "data": "n_n_capital" },
            { "data": "n_n_interes" },
            { "data": "n_n_seguro" },
            { "data": "n_n_comision" },
            { "data": "n_n_total" }
        ],
        "language": {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
        },
        dom: "Bfrtip",
        buttons: [
            {
                extend: "excelHtml5",
                text: "<span title='Exportar a Excel'><img src='" + rootUrl + "/img/excel.png' /> Exportar Excel</span>",
                filename: "Reporte de créditos",
                title: "",
                exportOptions: {
                    columns: [0, 1, 2]
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
            total2 = api
                .column(2)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            total3 = api
                .column(3)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
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

            // Total over this page
            pageTotal2 = api
                .column(2, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
            pageTotal3 = api
                .column(3, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                }, 0);
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

            // Update footer

            $(api.column(2).footer()).html(pageTotal2.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(3).footer()).html(pageTotal3.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(4).footer()).html(pageTotal4.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(5).footer()).html(pageTotal5.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(6).footer()).html(pageTotal6.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            $(api.column(7).footer()).html(pageTotal7.toFixed(2).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ","));           
            
        }

    });
}

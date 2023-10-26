
var datatable_solicitudes_detail;
$(document).ready(function () {
    
});

function NuevaSolicitud() {
    document.getElementById("txtMonto").value = "0.00"
    document.getElementById("txtPlazo").value = "0"

    document.getElementById("txtMonto").readOnly = false;
    document.getElementById("txtPlazo").readOnly = false;

    document.getElementById("btnSavesolicitud").disabled = false;

    document.getElementById("pnl-btn-1").style.display = 'flex';
    document.getElementById("pnl-btn-2").style.display = 'none';
    document.getElementById("panel_solicitudes_detalle").style.display = 'none';
    
}

function PerformSimulation() {
    var monto = document.getElementById("txtMonto").value;
    var plazo = document.getElementById("txtPlazo").value;

    //Validamos los datos ingresados
    if (monto <= 0 || plazo <= 0) {
        toastr.error("Debe ingresar el monto y el plazo");
        return;
    }
    else {
        GetSolicitudDetail(monto,plazo);

        document.getElementById("txtMonto").readOnly = true;
        document.getElementById("txtPlazo").readOnly = true;                
        document.getElementById("pnl-btn-1").style.display = 'none';
        document.getElementById("pnl-btn-2").style.display = 'flex';
        document.getElementById("panel_solicitudes_detalle").style.display = 'block';        

    }
    
}

function SolicitarCredito() {    
    swal({
        title: "¿Deseas solicitar el crédito con los datos de la simulación realizada?",
        text: "Se procederá a registrar tu solicitud en el sistema",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((answer) => {
        if (answer) {
            $.ajax({
                type: "POST",
                url: rootUrl + "/Simulator/SaveSolicitud",
                success: function (response) {
                    if (response.ok==true) {
                        swal(response.message, "Deberá esperar a que su solicitud sea atendida. Podrá revisar el estado de esta solicitud en el menu 'Solicitudes'.", "success");                        
                        document.getElementById("btnSavesolicitud").disabled = true;
                    }
                    else {
                        toastr.error(response.message);
                    }
                }
            });
        }
    });       
}

function GetSolicitudDetail(monto,plazo) {
    document.getElementById("panel_solicitudes_detalle").style.display = "block";

    $('#tb_solicitudes_detalle').DataTable().destroy();
    datatable_solicitudes_detail = $('#tb_solicitudes_detalle').DataTable({
        "ajax": {
            "url": rootUrl + "/Simulator/PerformSimulations",
            "type": "POST",
            data: {
                'monto': monto,
                'plazo': plazo                
            },
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

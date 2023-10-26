package com.utp.apicreditos.entity;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.math.BigDecimal;
import java.util.UUID;

@Entity
@Table(name = "tbl_aportaciones")
@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class Aportation {

    @Id
    @Column(name = "C_C_CLIENTE", columnDefinition = "uniqueidentifier DEFAULT NEWID()", insertable = false, updatable = false)
    private UUID id;

    @ManyToOne
    @JoinColumn(name = "C_T_CIP")
    private User userCIP;

    @Column(name = "C_T_ORIGEN")
    private String ctOrigin;

    @Column(name = "N_I_AÑO")
    private Integer yearAportation;

    @Column(name = "N_N_APORTE01")
    private BigDecimal firstMonthAportation;

    @Column(name = "N_N_APORTE02")
    private BigDecimal secondMonthAportation;

    @Column(name = "N_N_APORTE03")
    private BigDecimal thirdMonthAportation;
    @Column(name = "N_N_APORTE04")
    private BigDecimal fourthMonthAportation;

    @Column(name = "N_N_APORTE05")
    private BigDecimal fifthMonthAportation;

    @Column(name = "N_N_APORTE06")
    private BigDecimal sixthMonthAportation;
    @Column(name = "N_N_APORTE07")
    private BigDecimal seventhMonthAportation;

    @Column(name = "N_N_APORTE08")
    private BigDecimal eighthMonthAportation;

    @Column(name = "N_N_APORTE09")
    private BigDecimal ninthMonthAportation;

    @Column(name = "N_N_APORTE10")
    private BigDecimal tenthMonthAportation;

    @Column(name = "N_N_APORTE11")
    private BigDecimal eleventhMonthAportation;

    @Column(name = "N_N_APORTE12")
    private BigDecimal twelfthMonthAportation;

    @Column(name = "N_N_TOTAL")
    private BigDecimal total;

}

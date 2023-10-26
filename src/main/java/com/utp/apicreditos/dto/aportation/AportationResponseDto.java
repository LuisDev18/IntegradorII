package com.utp.apicreditos.dto.aportation;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.math.BigDecimal;

@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
public class AportationResponseDto {

    private String ctOrigin;


    private Integer yearAportation;


    private BigDecimal firstMonthAportation;


    private BigDecimal secondMonthAportation;


    private BigDecimal thirdMonthAportation;

    private BigDecimal fourthMonthAportation;


    private BigDecimal fifthMonthAportation;


    private BigDecimal sixthMonthAportation;

    private BigDecimal seventhMonthAportation;


    private BigDecimal eighthMonthAportation;


    private BigDecimal ninthMonthAportation;


    private BigDecimal tenthMonthAportation;


    private BigDecimal eleventhMonthAportation;


    private BigDecimal twelfthMonthAportation;


    private BigDecimal total;
}

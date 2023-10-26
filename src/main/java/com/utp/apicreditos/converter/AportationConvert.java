package com.utp.apicreditos.converter;

import com.utp.apicreditos.dto.aportation.AportationResponseDto;
import com.utp.apicreditos.entity.Aportation;
import org.springframework.stereotype.Component;

@Component
public class AportationConvert extends AbstractConverter<Aportation, AportationResponseDto> {

    @Override
    public AportationResponseDto fromEntity(Aportation aportation) {
        AportationResponseDto dto = new AportationResponseDto();
        dto.setCtOrigin(aportation.getCtOrigin());
        dto.setYearAportation(aportation.getYearAportation());
        dto.setFirstMonthAportation(aportation.getFirstMonthAportation());
        dto.setSecondMonthAportation(aportation.getSecondMonthAportation());
        dto.setThirdMonthAportation(aportation.getThirdMonthAportation());
        dto.setFourthMonthAportation(aportation.getFourthMonthAportation());
        dto.setFifthMonthAportation(aportation.getFifthMonthAportation());
        dto.setSixthMonthAportation(aportation.getSixthMonthAportation());
        dto.setSeventhMonthAportation(aportation.getSeventhMonthAportation());
        dto.setEighthMonthAportation(aportation.getEighthMonthAportation());
        dto.setNinthMonthAportation(aportation.getNinthMonthAportation());
        dto.setTenthMonthAportation(aportation.getTenthMonthAportation());
        dto.setEleventhMonthAportation(aportation.getEleventhMonthAportation());
        dto.setTwelfthMonthAportation(aportation.getTwelfthMonthAportation());
        dto.setTotal(aportation.getTotal());
        return dto;

    }

    @Override
    public Aportation fromDto(AportationResponseDto dto) {
        return null;
    }


}

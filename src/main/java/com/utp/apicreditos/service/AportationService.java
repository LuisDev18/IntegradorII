package com.utp.apicreditos.service;

import com.utp.apicreditos.dto.aportation.AportationResponseDto;

import java.util.List;

public interface AportationService {
  List<AportationResponseDto> getAportations();
}

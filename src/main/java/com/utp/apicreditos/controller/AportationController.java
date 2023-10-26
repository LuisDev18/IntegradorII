package com.utp.apicreditos.controller;

import com.utp.apicreditos.dto.aportation.AportationResponseDto;
import com.utp.apicreditos.service.AportationService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/v1")
@RequiredArgsConstructor
public class AportationController {
    private final AportationService aportationService;

    @GetMapping(value = "/aportations", produces = "application/json")
    public ResponseEntity<List<AportationResponseDto>> getAportations() {
        List<AportationResponseDto> aportations = aportationService.getAportations();
        return ResponseEntity.ok(aportations);
    }
}

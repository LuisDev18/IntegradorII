package com.utp.apicreditos.controller;

import com.utp.apicreditos.dto.LoginRequestDto;
import com.utp.apicreditos.dto.LoginResponseDto;
import com.utp.apicreditos.service.UserService;
import com.utp.apicreditos.util.WrapperResponse;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/v1")
@RequiredArgsConstructor
public class UserController {

    private final UserService userService;

    @PostMapping(value = "/usuarios/login")
    public ResponseEntity<WrapperResponse<LoginResponseDto>> login(
            @RequestBody LoginRequestDto request) {
        LoginResponseDto response = userService.login(request);
        return new WrapperResponse<>(true, "success", response).createResponse(HttpStatus.OK);
    }

    @GetMapping(value = "/hello")
    public ResponseEntity<WrapperResponse<String>> hello() {
        return new WrapperResponse<>(true, "success", "Hello World").createResponse(HttpStatus.OK);
    }


}

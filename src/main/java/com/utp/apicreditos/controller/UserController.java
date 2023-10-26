package com.utp.apicreditos.controller;

import com.utp.apicreditos.dto.login.LoginRequestDto;
import com.utp.apicreditos.dto.login.LoginResponseDto;
import com.utp.apicreditos.dto.user.UserProfileResponseDto;
import com.utp.apicreditos.dto.user.UserUpdateRequestDto;
import com.utp.apicreditos.service.UserService;
import com.utp.apicreditos.util.WrapperResponse;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/v1")
@RequiredArgsConstructor
public class UserController {

    private final UserService userService;

    @PostMapping(value = "/user/login")
    public ResponseEntity<WrapperResponse<LoginResponseDto>> login(
            @Valid @RequestBody LoginRequestDto request) {
        LoginResponseDto response = userService.login(request);
        return new WrapperResponse<>(true, "success", response).createResponse(HttpStatus.OK);
    }


    @PutMapping(value = "/user/update-profile", consumes = "application/json", produces = "application/json")
    public ResponseEntity<WrapperResponse<String>> updateProfile(@Valid @RequestBody UserUpdateRequestDto user) {
        userService.updateUser(user);
        return new WrapperResponse<>(true, "User was update success", "Profile update").createResponse(HttpStatus.OK);
    }

    @GetMapping(value = "/user/profile", produces = "application/json")
    public ResponseEntity<WrapperResponse<UserProfileResponseDto>> getProfile() {
        UserProfileResponseDto response = userService.getProfileUser();
        return new WrapperResponse<>(true, "success", response).createResponse(HttpStatus.OK);
    }


}

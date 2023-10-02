package com.utp.apicreditos.service;

import com.utp.apicreditos.dto.LoginRequestDto;
import com.utp.apicreditos.dto.LoginResponseDto;

public interface UserService {

    public LoginResponseDto login(LoginRequestDto loginRequestDto);

}

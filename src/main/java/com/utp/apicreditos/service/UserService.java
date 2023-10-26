package com.utp.apicreditos.service;

import com.utp.apicreditos.dto.login.LoginRequestDto;
import com.utp.apicreditos.dto.login.LoginResponseDto;
import com.utp.apicreditos.dto.user.UserProfileResponseDto;
import com.utp.apicreditos.dto.user.UserUpdateRequestDto;

public interface UserService {

    LoginResponseDto login(LoginRequestDto loginRequestDto);
    void updateUser(UserUpdateRequestDto userUpdateRequestDto);

    UserProfileResponseDto getProfileUser();

}

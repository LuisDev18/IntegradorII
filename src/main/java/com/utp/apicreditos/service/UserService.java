package com.utp.apicreditos.service;

import com.utp.apicreditos.dto.LoginRequestDto;
import com.utp.apicreditos.dto.LoginResponseDto;
import com.utp.apicreditos.dto.UserProfileResponseDto;
import com.utp.apicreditos.dto.UserUpdateRequestDto;
import com.utp.apicreditos.entity.User;

public interface UserService {

    LoginResponseDto login(LoginRequestDto loginRequestDto);
    void updateUser(UserUpdateRequestDto userUpdateRequestDto);

    UserProfileResponseDto getProfileUser();

}

package com.utp.apicreditos.service;


import com.utp.apicreditos.converter.UserConverter;
import com.utp.apicreditos.dto.login.LoginRequestDto;
import com.utp.apicreditos.dto.login.LoginResponseDto;
import com.utp.apicreditos.dto.login.UserResponseDto;
import com.utp.apicreditos.entity.User;
import com.utp.apicreditos.exception.InvalidCredentialsException;
import com.utp.apicreditos.repository.UserRepository;
import com.utp.apicreditos.security.JwtService;
import com.utp.apicreditos.service.impl.UserServiceImpl;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.ArgumentMatchers;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;

import java.util.Optional;

@ExtendWith(MockitoExtension.class)
public class UserServiceImplTest {

    @Mock
    private UserRepository userRepository;
    @Mock
    private AuthenticationManager authenticationManager;
    @Mock
    private UserConverter usuarioConverter;

    @Mock
    private JwtService jwtService;

    @InjectMocks
    private UserServiceImpl userServiceImpl;


    @Test
    public void loginUserTestSuccess() {
        //GIVEN
        LoginRequestDto loginRequestDto = new LoginRequestDto("12345678", "adidas");
        User user = new User();
        // Configura el usuario simulado que se espera encontrar en el repositorio
        Mockito.when(userRepository.findByCtCip(Long.valueOf(loginRequestDto.getUsernameCIP()))).thenReturn(Optional.of(user));
        // Configura el token JWT simulado
        Mockito.when(jwtService.generateToken(user)).thenReturn("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzUxMiJ9.eyJ1c2VybmFtZSI6IjEyMzQwNTIyMiIsInJvbGVzIjoiW1VTRVJdIiwiTm9tYnJlQ29tcGxldG8iOiJMZXNseSBBZ3VpbGFyIExvcGV6IiwiaWF0IjoxNjk4MzU2MTE2LCJleHAiOjE2OTgzNTc1NTZ9.NaS7ewHd3m8yxgYFsLRZrRNV24vV6MTVEyuQ67dHoBM_UyRzv-J5mTPNvvYFdApz75_VZ2xj5WoXlPXz2lOklt2511QWPwYjK0JamKyDlyX22mkyv0GCZ0gL48PNnpBsm8bkafvlEZWSZXQJsLEwSLy4j9HIA1JWfviORFxd6noVVIQob56xda1Z-1V5gsRP8Bdk8f7XJEcgH4opTvYQDVtSRftIbAbVRBuoSw_IR115f_YdAsYMr-cXHABzwDyV4YCcDcW9nduBeKhV1FrHjCOxkker8uICHrhY2w_5u3CPZmYNOVCJFWeMTs6IBuV0F7-y4EhMIz7I4TzJGbIO1w");
        //Configura el usuario simulado que se espera devolver
        Mockito.when(usuarioConverter.fromEntity(user)).thenReturn(new UserResponseDto(Long.valueOf("12345678"), "USER"));
        // WHEN
        LoginResponseDto response = userServiceImpl.login(loginRequestDto);
        // THEN
        UserResponseDto userResponseDto = response.getUsuario();
        Assertions.assertEquals(userResponseDto.getUsernameCIP(), Long.valueOf("12345678"));
        Assertions.assertEquals(userResponseDto.getRole(), "USER");
        Assertions.assertEquals(response.getToken(), "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzUxMiJ9.eyJ1c2VybmFtZSI6IjEyMzQwNTIyMiIsInJvbGVzIjoiW1VTRVJdIiwiTm9tYnJlQ29tcGxldG8iOiJMZXNseSBBZ3VpbGFyIExvcGV6IiwiaWF0IjoxNjk4MzU2MTE2LCJleHAiOjE2OTgzNTc1NTZ9.NaS7ewHd3m8yxgYFsLRZrRNV24vV6MTVEyuQ67dHoBM_UyRzv-J5mTPNvvYFdApz75_VZ2xj5WoXlPXz2lOklt2511QWPwYjK0JamKyDlyX22mkyv0GCZ0gL48PNnpBsm8bkafvlEZWSZXQJsLEwSLy4j9HIA1JWfviORFxd6noVVIQob56xda1Z-1V5gsRP8Bdk8f7XJEcgH4opTvYQDVtSRftIbAbVRBuoSw_IR115f_YdAsYMr-cXHABzwDyV4YCcDcW9nduBeKhV1FrHjCOxkker8uICHrhY2w_5u3CPZmYNOVCJFWeMTs6IBuV0F7-y4EhMIz7I4TzJGbIO1w");

    }

    @Test
    public void loginTestAuthenticationException(){
        // GIVEN
        LoginRequestDto loginRequestDto = new LoginRequestDto("12345678", "adidas");
        //when
        Mockito.when(authenticationManager.authenticate(ArgumentMatchers.any(UsernamePasswordAuthenticationToken.class)))
                .thenThrow(new BadCredentialsException("Error de autenticación"));
        //THEN
        // Verifica que se maneje correctamente la AuthenticationException y se lance InvalidCredentialsException
        Assertions.assertThrows(InvalidCredentialsException.class, () -> userServiceImpl.login(loginRequestDto));
    }

    @Test
    public void updateUserTest() {

    }

    @Test
    public void getUserProfileTest() {

    }
}

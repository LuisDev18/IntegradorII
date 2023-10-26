package com.utp.apicreditos.service.impl;

import com.utp.apicreditos.converter.UserConverter;
import com.utp.apicreditos.dto.login.LoginRequestDto;
import com.utp.apicreditos.dto.login.LoginResponseDto;
import com.utp.apicreditos.dto.user.UserProfileResponseDto;
import com.utp.apicreditos.dto.user.UserUpdateRequestDto;
import com.utp.apicreditos.entity.User;
import com.utp.apicreditos.exception.InvalidCredentialsException;
import com.utp.apicreditos.exception.MessageException;
import com.utp.apicreditos.repository.UserRepository;
import com.utp.apicreditos.security.JwtService;
import com.utp.apicreditos.service.UserService;
import com.utp.apicreditos.util.AuthenticateHelper;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.AuthenticationException;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
@RequiredArgsConstructor
@Slf4j
public class UserServiceImpl implements UserService {

    private final UserRepository usuarioRepository;

    private final PasswordEncoder encoder;

    private final AuthenticationManager authenticationManager;

    private final JwtService jwtService;

    private final UserConverter usuarioConverter;

    @Override
    public LoginResponseDto login(LoginRequestDto loginRequestDto) {
        try {
            authenticationManager.authenticate(new UsernamePasswordAuthenticationToken(loginRequestDto.getUsernameCIP(), loginRequestDto.getPassword()));
            var usuario = usuarioRepository.findByCtCip(loginRequestDto.getUsernameCIP()).orElseThrow();
            var jwtToken = jwtService.generateToken(usuario);
            return new LoginResponseDto(usuarioConverter.fromEntity(usuario), jwtToken);
        } catch (AuthenticationException e) {
            log.info(e.getMessage(), e);
            throw new InvalidCredentialsException(MessageException.INVALID_CREDENTIALS);
        }
    }

    @Override
    public void updateUser(UserUpdateRequestDto userUpdateRequestDto) {
        Optional<User> userDb = usuarioRepository.findByCtCip(AuthenticateHelper.getAuthenticateUser());
        if (userDb.isPresent()) {
            User user = userDb.get();
            user.setCtEmail(userUpdateRequestDto.getEmail());
            user.setCtTelefono(userUpdateRequestDto.getCellphone());
            user.setCtDireccion(userUpdateRequestDto.getAddress());
            usuarioRepository.save(user);
        }
    }


    @Override
    public UserProfileResponseDto getProfileUser() {
        Optional<User> userDb = usuarioRepository.findByCtCip(AuthenticateHelper.getAuthenticateUser());
        if (userDb.isPresent()) {
            User user = userDb.get();
            return usuarioConverter.fromEntityToUserProfile(user);
        }
        throw new RuntimeException(MessageException.PROFILE_NOT_FOUND);
    }


}

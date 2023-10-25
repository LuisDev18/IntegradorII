package com.utp.apicreditos.service.impl;

import com.utp.apicreditos.converter.UserConverter;
import com.utp.apicreditos.dto.LoginRequestDto;
import com.utp.apicreditos.dto.LoginResponseDto;
import com.utp.apicreditos.dto.UserUpdateRequestDto;
import com.utp.apicreditos.entity.User;
import com.utp.apicreditos.exception.ValidateServiceException;
import com.utp.apicreditos.repository.UserRepository;
import com.utp.apicreditos.security.JwtService;
import com.utp.apicreditos.service.UserService;
import io.jsonwebtoken.JwtException;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
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
        } catch (JwtException e) {
            log.info(e.getMessage(), e);
            throw new ValidateServiceException(e.getMessage());
        } catch (Exception e) {
            log.info(e.getMessage(), e);
            throw new ValidateServiceException(e.getMessage());
        }
    }

    @Override
    public void updateUser(UserUpdateRequestDto userUpdateRequestDto) {
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
        if (authentication != null && authentication.getPrincipal() instanceof UserDetails) {
            // Obtener el UserDetails desde la autenticación
            UserDetails userDetails = (UserDetails) authentication.getPrincipal();

            // Obtener el campo "username" del token
            String username = userDetails.getUsername();

            Optional<User> userDb = usuarioRepository.findByCtCip(username);
            if (userDb.isPresent()) {
                User user = userDb.get();
                user.setCtEmail(userUpdateRequestDto.getEmail());
                user.setCtTelefono(userUpdateRequestDto.getCellphone());
                user.setCtDireccion(userUpdateRequestDto.getAddress());
                usuarioRepository.save(user);
            }

        }
    }
}

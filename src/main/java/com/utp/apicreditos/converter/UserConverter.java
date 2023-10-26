package com.utp.apicreditos.converter;

import com.utp.apicreditos.dto.user.UserProfileResponseDto;
import com.utp.apicreditos.dto.login.UserResponseDto;
import com.utp.apicreditos.entity.Role;
import com.utp.apicreditos.entity.User;
import org.springframework.stereotype.Component;

@Component
public class UserConverter extends AbstractConverter<User, UserResponseDto>{

    @Override
    public UserResponseDto fromEntity(User entity) {
        if (entity == null) {
            return null;
        } else {
            return UserResponseDto.builder()
                    .usernameCIP(entity.getCtCip())
                    .role(entity.getRole().name())
                    .build();
        }
    }

    @Override
    public User fromDto(UserResponseDto dto) {
        if (dto == null) {
            return null;
        } else {
            Role rol = Role.valueOf(dto.getRole().toUpperCase());
            return User.builder()
                    .ctCip(dto.getUsernameCIP())
                    .role(rol)
                    .build();
        }
    }

    public UserProfileResponseDto fromEntityToUserProfile (User user){
        if(user == null) {
            return null;
        } else {
            return UserProfileResponseDto.builder()
                    .infoUser(user.getCtCliente())
                    .address(user.getCtDireccion())
                    .email(user.getCtEmail())
                    .degree(user.getCtGrado())
                    .cellphone(user.getCtTelefono())
                    .birthDate(user.getDNacimiento())
                    .build();
        }
    }
}

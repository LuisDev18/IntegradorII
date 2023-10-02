package com.utp.apicreditos.converter;

import com.utp.apicreditos.dto.UserResponseDto;
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
                    .id(entity.getId())
                    .usernameCIP(entity.getUsernameCIP())
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
                    .id(dto.getId())
                    .usernameCIP(dto.getUsernameCIP())
                    .role(rol)
                    .build();
        }
    }
}

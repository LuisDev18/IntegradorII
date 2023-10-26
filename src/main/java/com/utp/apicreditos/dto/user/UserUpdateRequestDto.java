package com.utp.apicreditos.dto.user;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class UserUpdateRequestDto {
    private String address;
    @Email
    private String email;
    @Size(max = 9)
    @Pattern(regexp = "^[0-9]*$", message = "El número de celular debe contener solo dígitos")
    private String cellphone;
}

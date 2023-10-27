package com.utp.apicreditos.dto.login;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Size;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class LoginRequestDto {
    @Size(max = 9)
    @Pattern(regexp = "^[0-9]*$", message = "El codigo CIP debe contener solo 9 dígitos")
    @NotBlank(message = "El codigo CIP es obligatorio")
    private String usernameCIP;
    @NotBlank(message = "La contraseña es obligatoria y no puede estar vacía")
    private String password;
}

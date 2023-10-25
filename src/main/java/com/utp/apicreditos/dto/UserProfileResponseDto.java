package com.utp.apicreditos.dto;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.sql.Date;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class UserProfileResponseDto {
   private String infoUser;
   private String address;
   private String email;
   private String degree;
   private String cellphone;
   private Date birthDate;

}

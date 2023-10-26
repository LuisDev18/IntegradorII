package com.utp.apicreditos.exception;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDateTime;

@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
public class ValidationFieldError {
    private String field;
    private String message;
    private LocalDateTime timestamp;
    private String errorCode;
    private String path;
}

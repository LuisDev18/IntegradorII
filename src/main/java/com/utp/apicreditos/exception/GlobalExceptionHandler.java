package com.utp.apicreditos.exception;

import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.FieldError;
import org.springframework.validation.ObjectError;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@ControllerAdvice
public class GlobalExceptionHandler extends ResponseEntityExceptionHandler {


    @ExceptionHandler(InvalidCredentialsException.class)
    public ResponseEntity<CustomErrorResponse> handleInvalidCredentialsException(InvalidCredentialsException ex, WebRequest webRequest) {
        CustomErrorResponse errors = new CustomErrorResponse(
                LocalDateTime.now(),
                ex.getMessage(),
                webRequest.getDescription(false),
                "BAD_REQUEST"
        );
        return new ResponseEntity<>(errors, HttpStatus.BAD_REQUEST);
    }

    @ExceptionHandler(Exception.class)
    public ResponseEntity<CustomErrorResponse> handleGlobalException(Exception exception,
                                                              WebRequest webRequest){
        CustomErrorResponse errorDetails= new CustomErrorResponse(
                LocalDateTime.now(),
                exception.getMessage(),
                webRequest.getDescription(false),
                "INTERNAL_SERVER_ERROR"
        );
        return new ResponseEntity<>(errorDetails, HttpStatus.INTERNAL_SERVER_ERROR);
    }

    @Override
    protected ResponseEntity<Object> handleMethodArgumentNotValid(MethodArgumentNotValidException ex,
                                                                  HttpHeaders headers,
                                                                  HttpStatusCode status,
                                                                  WebRequest request) {
        List<ValidationFieldError> errors = new ArrayList<>();
        List<ObjectError> errorList = ex.getBindingResult().getAllErrors();
        LocalDateTime timestamp = LocalDateTime.now();
        String path = request.getDescription(false);

        errorList.forEach((error) -> {
            String fieldName = ((FieldError) error).getField();
            String message = error.getDefaultMessage();
            String errorCode = "BAD_REQUEST";

            ValidationFieldError fieldError = new ValidationFieldError(fieldName, message, timestamp, errorCode, path);
            errors.add(fieldError);
        });

        return new ResponseEntity<>(errors, HttpStatus.BAD_REQUEST);
    }
}

package com.utp.apicreditos.util;

import com.utp.apicreditos.exception.MessageException;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;

public class AuthenticateHelper {

    public static String getAuthenticateUser(){
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
        if(authentication != null && authentication.getPrincipal() instanceof UserDetails userDetails){
            return userDetails.getUsername();
        }
        throw new RuntimeException(MessageException.USER_AUTHENTICATED_NOT_FOUND);
    }


}

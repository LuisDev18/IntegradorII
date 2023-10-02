package com.utp.apicreditos.entity;

import lombok.Getter;

@Getter
public enum Role {

    ADMIN("ROLE_ADMIN"),
    USER("ROLE_USER");

    private String descripcion;

    private Role(String descripcion) {
        this.descripcion = descripcion;
    }

}

package com.utp.apicreditos.repository;

import com.utp.apicreditos.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface UserRepository extends JpaRepository<User, Long>{
   Optional<User> findByUsernameCIP(String usernameCIP);
}
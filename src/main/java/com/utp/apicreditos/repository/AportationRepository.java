package com.utp.apicreditos.repository;

import com.utp.apicreditos.entity.Aportation;
import com.utp.apicreditos.entity.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

@Repository
public interface AportationRepository extends JpaRepository<Aportation, UUID> {

    List<Aportation> findByUserCIP(User user);
}

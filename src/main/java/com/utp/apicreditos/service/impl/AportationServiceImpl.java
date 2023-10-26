package com.utp.apicreditos.service.impl;

import com.utp.apicreditos.converter.AportationConvert;
import com.utp.apicreditos.dto.aportation.AportationResponseDto;
import com.utp.apicreditos.entity.Aportation;
import com.utp.apicreditos.entity.User;
import com.utp.apicreditos.exception.MessageException;
import com.utp.apicreditos.repository.AportationRepository;
import com.utp.apicreditos.repository.UserRepository;
import com.utp.apicreditos.service.AportationService;
import com.utp.apicreditos.util.AuthenticateHelper;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class AportationServiceImpl implements AportationService {

    private final UserRepository usuarioRepository;
    private final AportationRepository aportationRepository;
    private final AportationConvert aportationConvert;

    @Override
    public List<AportationResponseDto> getAportations() {
        Optional<User> userDb = usuarioRepository.findByCtCip(AuthenticateHelper.getAuthenticateUser());
        if (userDb.isPresent()) {
            User user = userDb.get();

            List<Aportation> aportations = aportationRepository.findByUserCIP(user);

            return aportations.stream()
                    //.map(aportation -> aportationConvert.fromEntity(aportation))
                    .map(aportationConvert::fromEntity)
                    .collect(Collectors.toList());
        }
        throw new RuntimeException(MessageException.USER_AUTHENTICATED_NOT_FOUND);
    }

}

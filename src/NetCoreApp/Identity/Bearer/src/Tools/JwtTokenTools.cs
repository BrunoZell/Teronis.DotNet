﻿using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Teronis.Identity.Extensions;

namespace Teronis.Identity.Tools
{
    public static class JwtTokenTools
    {
        /// <summary>
        /// Generates a JWT-token from token descriptor.
        /// </summary>
        public static string GenerateJwtToken(SecurityTokenDescriptor securityTokenDescriptor, bool setDefaultTimesOnTokenCreation)
        {
            // We want to move claims to the claims of subject.
            securityTokenDescriptor.MoveClaimsToSubjectClaims();
            var tokenHandler = new JwtSecurityTokenHandler() { SetDefaultTimesOnTokenCreation = setDefaultTimesOnTokenCreation };
            // Create security token.
            var securityToken = tokenHandler.CreateJwtSecurityToken(securityTokenDescriptor);
            // Generate token string.
            return tokenHandler.WriteToken(securityToken);
        }
    }
}

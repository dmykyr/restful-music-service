using AutoMapper;
using MusicService.Data.Repositories;
using MusicService.DTOs;
using MusicService.Models;
using MusicService.Responses;

namespace MusicService.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(
            UserRepository userRepository, 
            RoleRepository roleRepository, 
            IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Get (Guid id)
        {
            var user = await _userRepository.Get(id);
            return _mapper.Map<UserResponse>(user);
        }
        
        public async Task<UserResponse> Create (CreateUserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            userEntity.CreatedAt = DateTime.Now;

            var createdUser = await _userRepository.Add(userEntity);
            return _mapper.Map<UserResponse>(createdUser);
        }

        public async Task<UserResponse> Update(Guid id, UpdateUserDTO userDTO)
        {
            var user = await _userRepository.Get(id);
            
            if(user == null)
            {
                return null;
            }

            user.Nickname = userDTO.Nickname ?? user.Nickname;
            user.Password = userDTO.Password ?? user.Password;
            user.Login = userDTO.Login ?? user.Login;

            await _userRepository.Update(user);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> Delete (Guid userId)
        {
            var user = await _userRepository.Delete(userId);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> ChangeUserRole(Guid userId, string roleName)
        {
            var user = await _userRepository.Get(userId);
            var role = await _roleRepository.GetByName(roleName);

            if (user == null)
            {
                return null;
            }

            if(role == null)
            {
                return null;
            }

            if(user.RoleId == role.Id)
            {
                return null;
            }
            
            user.RoleId = role.Id;
            await _userRepository.Update(user);
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<IEnumerable<AlbumResponse>> GetFavoriteAlbums(Guid userId, string searchName)
        {
            var albums = await _userRepository.GetFavoriteAlbums(userId, searchName);
            return _mapper.Map<IEnumerable<AlbumResponse>>(albums);
        }

        public async Task<IEnumerable<ArtistResponse>> GetFavoriteArtists(Guid userId, string searchName)
        {
            var artists = await _userRepository.GetFavoriteArtists(userId, searchName);
            return _mapper.Map<IEnumerable<ArtistResponse>>(artists);
        }

        public async Task AddFavoriteAlbum (Guid userId, Guid albumId)
        {
            await _userRepository.AddFavoriteAlbum(userId, albumId);
        }

        public async Task AddFavoriteArtist(Guid userId, Guid artistId)
        {
            await _userRepository.AddFavoriteArtist(userId, artistId);
        }

        public async Task RemoveFavoriteAlbum(Guid userId, Guid albumId)
        {
            await _userRepository.RemoveFavoriteAlbum(userId, albumId);
        }

        public async Task RemoveFavoriteArtist(Guid userId, Guid artistId)
        {
            await _userRepository.RemoveFavoriteArtist(userId, artistId);
        }
    }
}

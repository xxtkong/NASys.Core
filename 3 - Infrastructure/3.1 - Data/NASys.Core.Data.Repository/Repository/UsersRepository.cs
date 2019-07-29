using Dapper;
using NASys.Core.Data.Context;
using NASys.Core.Data.Context.Config;
using NASys.Core.Data.Repository.Dapper.Common;
using NASys.Core.Data.Repository.EntityFramework.Common;
using NASys.Core.Domain.Entities;
using NASys.Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace NASys.Core.Data.Repository.Repository
{
    public class UsersRepository : DapperRepository<Users>, IUsersRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;
        public UsersRepository(NASysContext dbContext) : base(dbContext.DbConnections)
        {
            this._dbConnectionFactory = dbContext.DbConnections;
           
        }
        //public override Users Find(int id, IDbTransaction transaction = null)
        //{
        //    using (var cn = _dbConnectionFactory["read"])
        //    {
        //        var album = cn.Query<Users, Artist, Genre, Album>
        //            ("SELECT * " +
        //             "  FROM Users Al" +
        //             "  JOIN Artist Ar ON Ar.ArtistId = Al.ArtistId" +
        //             "  JOIN Genre Ge ON Ge.GenreId = Al.GenreId" +
        //             " WHERE Al.AlbumId = @AlbumId",
        //                (al, ar, ge) =>
        //                {
        //                    al.Artist = ar;
        //                    al.Genre = ge;
        //                    return al;
        //                },
        //                new { AlbumId = id }, splitOn: "AlbumId, ArtistId, GenreId").FirstOrDefault();
        //        return album;
        //    }
        //}
    }
}

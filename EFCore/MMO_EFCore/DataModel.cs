using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MMO_EFCore
{
    // 오늘의 주제 : SQL 직접 호출

    // 경우에 따라 직접 만든 SQL 호출할 수 있다.
    // ex) LINQ로 처리할 수 없는 것 -> Stored Procedure 호출 등
    // ex) 성능 최적화 등

    // 1) FromSql ->FromSqlRaw / FromSqlInterpolated
    // - EF Core 쿼리에 Raw SQL 추가

    // 2) ExecuteSqlCommand -> ExecuteSqlRaw / ExecuteSqlInterpolated
    // - Non-Query (SELECT가 아닌) SQL

    // 3) Reload
    // - Tracked Entity가 이미 있다.
    // - 2)번에 의해 DB 정보가 변경 되었다면?
    // Reload

    [Table("Item")]
    public class Item
    {
        public bool SoftDeleted { get; set; }

        // 이름Id -> PK
        public int ItemId { get; set; }
        public int TemplateId { get; set; } // 101 = 집행검
        public DateTime CreateDate { get; private set; }

        public int ItemGrade { get; set; }

        // 다른 클래스 참조 -> FK (Navigational Property)

        //[ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public Player Owner { get; set; }

    }

    public class EventItem : Item
    {
        public DateTime DestroyDate { get; set; }
    }

    // 만들어진 시간 추적
    public interface ILogEntity
    {
        DateTime CreateTime { get; }
        void SetCreateTime();
    }

    // Entity 클래스 이름 = 테이블 이름 = Player
    [Table("Player")]
    public class Player : ILogEntity
    {
        // 이름Id -> PK
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(20)]
        // Alternate Key
        public string Name { get; set; }
        // [InverseProperty("Owner")]
        public Item OwnedItem { get; set; }
        public Guild Guild { get; set; }

        public DateTime CreateTime { get; private set; }

        public void SetCreateTime()
        {
            CreateTime = DateTime.Now;
        }
    }

    [Table("Guild")]
    public class Guild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public ICollection<Player> Members { get; set; }
    }

    // DTO (Data Transfer Object)
    public class GuildDto
    {
        public int GuildId { get; set; }
        public string Name { get; set; }
        public int MemberCount { get; set; }
    }
}

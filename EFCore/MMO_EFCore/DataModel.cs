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
    // 오늘의 주제 : 초기값 (Default Value)

    // 기본값 설정하는 방법이 여러가지가 있다.
    // 주의해서 볼 것
    // 1) Entity Class 자체의 초기값으로 붙는지
    // 2) DB Table 차원에서 초기값으로 적용되는지
    // - 결과는 같은거 아닐까?
    // - EF <-> DB 외에 다른 경로로 DB 사용한다면, 차이가 날 수 있다.
    // ex) SQL Script

    // 1) Auto-Property Initlalizer (C# 5.0)   -> public DateTime CreateDate { get; private set; } = new DateTime(2020, 1, 1);
    // - Entity 차원의 초기값 -> SaveChanges로 DB 적용
    //  2) Fluent Api
    // - DB Table DEFAULT를 적용
    //  - DateTime.Now ?
    // 3) SQL Fragment (새로운 값이 추가되는 시점에 DB족에서 실행)
    // - .HasDefaultValueSql
    // 4) Value Generator (EF Core에서 실행됨)
    // - 일종의 Generator 규칙

    [Table("Item")]
    public class Item
    {
        public bool SoftDeleted { get; set; }

        // 이름Id -> PK
        public int ItemId { get; set; }
        public int TemplateId { get; set; } // 101 = 집행검
        public DateTime CreateDate { get; private set; }

        // 다른 클래스 참조 -> FK (Navigational Property)
        //[ForeignKey("OwnerId")]
        public int OwnerId { get; set; }
        public Player Owner { get; set; }

    }

    public class EventItem : Item
    {
        public DateTime DestroyDate { get; set; }
    }

    public class PlayerNameGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            string name = $"Player_{DateTime.Now.ToString("yyyyMMdd")}";
            return name;
        }
    }

    // Entity 클래스 이름 = 테이블 이름 = Player
    [Table("Player")]
    public class Player
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

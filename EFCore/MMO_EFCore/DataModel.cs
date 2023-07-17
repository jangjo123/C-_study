﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    // 오늘의 주제 : State 조작

    // - 직접 State를 조작할 수 있따. (ex. 최적화 등)
    // ex) Entry().State = EntityState.Added
    // ex) Entry().Property("").IsModified = true

    // - TrackGraph
    // Relationship이 있는 Untracked Entity의 State 조작
    // ex) 전체 데이터 중에서 일부만 갱신하고 싶다거나.

    // - ChangeTracker
    // 상태 정보의 변화를 감지하고 싶을 때 유용
    // ex) Player의 Name이 바뀔 때 로그를 찍고 싶다.
    // ex) Validation 코드를 넣고 싶다거나
    // ex) Player가 생성된 시점을 CreateTime으로 정보를 추가하고 싶다.

    // Steps
    // 1) SaveChanges를 override
    // 2) ChangeTracker.Entries를 이용해서 바뀔 정보 추출 / 사용

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

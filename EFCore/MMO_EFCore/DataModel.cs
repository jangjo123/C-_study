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
    // 오늘의 주제 : DbContext 심화 과정 (최적화 등 때문에)
    // 1) ChangeTracker
    // - Tracking State 관련
    // 2) Database
    // - Transaction
    // - DB Creation/Mitgraion
    // - Raw SQL
    // 3) Model
    // - DB 모델링 관련

    // State (상태)
    // 0) Detached (No Tracking ! 추적되지 않는 상태. SaveChanges를 해도 존재도 모름)
    // 1) Unchanged (DB에 있고, 딱히 수정사항도 없었음. SaveChanges를 해도 아무 것도 X)
    // 2) Deleted (DB에는 아직 있지만, 삭제되어야 함. SaveChanges로 DB에 적용)
    // 3) Modified (DB에 있고, 클라에서 수정된 상태, SaveChanges로 DB에 적용)
    // 4) Added (DB에는 아직 없음, SaveChanges로 DB에 적용)

    // State 체크 방법
    // - Entry().State
    // - Entry().Property().IsModified
    // - Entry().Navigation().IsModified

    // State가 대부분 '직관적'이지만 Relationship이 개입하면 살짝 더 복잡함
    // - 1) Add/AddRange 사용할 떄의 상태 변화
    // -- NotTracking 상태라면 Added
    // -- Tracking 상태인데, FK 설정이 필요한지에 때라 Modified / 기존 상태 유지
    // - 2) Remove/RemoveRange 사용할 때의 상태 변화
    // - (DB에 의해 생성된 Key) && (C# 기본값 아님) -> 필요에 따라 Unchanged / Modified / Deleted
    // - (DB에 의해 생성된 Key 없음) || C# 기본값) -> Added
    // -- 삭제하는데 왜 굳이 Added이지? 동작 일관성 때문
    // -- Db에서도 일단 존재는 알아야.. Cascaed Delete 처리 등


    // - 3) Update / UpdateRange
    // - EF에서 Entity를 Update하는 기본적인 방법은 Update가 아님
    // - Tracked Entity 얻어오고 -> property 수정 -> SaveChanges
    // - Update는 Untracked Entity를 통으로 업데이트 할 때 (Disconnected State)

    // Relationship이 있을 때
    // - (DB에 의해 생성된 Key) && (0 아님) -> 필요에 따라 Unchanged / Modified / Deleted
    // - (DB에 의해 생성된 Key 없음) || 0) -> Added

    // EF Core에서 Update하면 일어나는 Step
    // 1) Update 호출
    // 2) Entity State =  Modified 로 변경
    // 3) 모든 Non-Relational Property의 IsModified = true로 변경

    // - 4) Attach
    // - Untracked Entity를 Tracked Entity로 변경

    // Relationship이 있을 때
    // - (DB에 의해 생성된 Key) && (0 아님) -> Unchanged
    // - (DB에 의해 생성된 Key 없음) || 0) -> Added

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

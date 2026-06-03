using System.ComponentModel.DataAnnotations;

public class SettingViewModel
{
    // Kullanıcı ayarları
    [Required]
    public string UserName { get; set; }

    // Sistem ayarları
    public bool AutoStudentNumber { get; set; }
    public int MaxUploadSizeMB { get; set; }
    public int HomeAnnouncementCount { get; set; }

    // Admin mi değil mi kontrolü
    public bool IsAdmin { get; set; }


    //İzinler Bölümü
    public bool CanTeacherAddStudent { get; set; }
    public bool CanTeacherEditStudent { get; set; }
    public bool CanTeacherDeleteStudent { get; set; }
    public bool CanStudentViewProfile { get; set; }
    public bool CanStudentEditProfile { get; set; }
}

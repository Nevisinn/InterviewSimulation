using System.Text.Json.Serialization;

namespace InterviewSimulation.Core.Models.Entities;

public class Vacancy
{
    public Vacancy(string name, Experience experience, string description, List<Skill> keySkills, List<ProfessionalRole> professionalRoles)
    {
        Name = name;
        Experience = experience;
        Description = description;
        KeySkills = keySkills;
        ProfessionalRoles = professionalRoles;
    }

    public string Name { get; private set; }
    public Experience Experience { get; private set; }
    public string Description { get; set; }
    [JsonPropertyName("key_skills")] public List<Skill> KeySkills { get; private set; }
    [JsonPropertyName("professional_roles")] public List<ProfessionalRole> ProfessionalRoles { get; private set; }
}

public class Experience
{
    public Experience(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}

public class Skill
{
    public Skill(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}

public class ProfessionalRole
{
    public ProfessionalRole(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}
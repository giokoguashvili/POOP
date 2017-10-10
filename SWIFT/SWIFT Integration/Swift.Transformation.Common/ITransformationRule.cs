using Swift.AltaSoftware.Wrapper.Swift;
using Swift.Integration.Db.Models;

namespace Swift.Transformation.Common
{
    public interface ITransformationRule { }
    public interface ITransformationRule<in TInput, out TOuptut> : ITransformationRule
        where TInput : IAsSwiftMessage
        where TOuptut : IDbModel
    {
        TOuptut Apply(TInput asSwiftMessage);
    }
}
